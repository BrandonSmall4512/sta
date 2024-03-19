package main

import (
	"database/sql"
	"encoding/json"
	"log"
	"net/http"

	"github.com/gorilla/mux"
	_ "github.com/lib/pq"
)

// User struct represents a user entity
type User struct {
	ID      int    `json:"id"`
	Name    string `json:"name"`
	Balance int    `json:"balance"`
}

// Quest struct represents a quest entity
type Quest struct {
	ID   int    `json:"id"`
	Name string `json:"name"`
	Cost int    `json:"cost"`
}

var db *sql.DB

func main() {
	// Database connection
	var err error
	db, err = sql.Open("postgres", "postgres://user:password@localhost/db_name?sslmode=disable")
	if err != nil {
		log.Fatal(err)
	}
	defer db.Close()

	// Router
	r := mux.NewRouter()
	r.HandleFunc("/users", createUser).Methods("POST")
	r.HandleFunc("/quests", createQuest).Methods("POST")
	r.HandleFunc("/complete", completeQuest).Methods("POST")
	r.HandleFunc("/user/{id}", getUser).Methods("GET")

	// Start server
	log.Fatal(http.ListenAndServe(":8080", r))
}

func createUser(w http.ResponseWriter, r *http.Request) {
	var user User
	err := json.NewDecoder(r.Body).Decode(&user)
	if err != nil {
		http.Error(w, err.Error(), http.StatusBadRequest)
		return
	}

	// Insert user into database
	_, err = db.Exec("INSERT INTO users (name, balance) VALUES ($1, $2)", user.Name, user.Balance)
	if err != nil {
		http.Error(w, err.Error(), http.StatusInternalServerError)
		return
	}

	w.WriteHeader(http.StatusCreated)
}

func createQuest(w http.ResponseWriter, r *http.Request) {
	var quest Quest
	err := json.NewDecoder(r.Body).Decode(&quest)
	if err != nil {
		http.Error(w, err.Error(), http.StatusBadRequest)
		return
	}

	// Insert quest into database
	_, err = db.Exec("INSERT INTO quests (name, cost) VALUES ($1, $2)", quest.Name, quest.Cost)
	if err != nil {
		http.Error(w, err.Error(), http.StatusInternalServerError)
		return
	}

	w.WriteHeader(http.StatusCreated)
}

func completeQuest(w http.ResponseWriter, r *http.Request) {
	var completion struct {
		UserID  int `json:"user_id"`
		QuestID int `json:"quest_id"`
	}
	err := json.NewDecoder(r.Body).Decode(&completion)
	if err != nil {
		http.Error(w, err.Error(), http.StatusBadRequest)
		return
	}

	// Update user balance and mark quest as completed
	tx, err := db.Begin()
	if err != nil {
		http.Error(w, err.Error(), http.StatusInternalServerError)
		return
	}
	defer tx.Rollback()

	_, err = tx.Exec("UPDATE users SET balance = balance + (SELECT cost FROM quests WHERE id = $1) WHERE id = $2", completion.QuestID, completion.UserID)
	if err != nil {
		http.Error(w, err.Error(), http.StatusInternalServerError)
		return
	}

	_, err = tx.Exec("INSERT INTO completed_quests (user_id, quest_id) VALUES ($1, $2)", completion.UserID, completion.QuestID)
	if err != nil {
		http.Error(w, err.Error(), http.StatusInternalServerError)
		return
	}

	err = tx.Commit()
	if err != nil {
		http.Error(w, err.Error(), http.StatusInternalServerError)
		return
	}

	w.WriteHeader(http.StatusOK)
}

func getUser(w http.ResponseWriter, r *http.Request) {
	params := mux.Vars(r)
	userID := params["id"]

	var user User
	err := db.QueryRow("SELECT id, name, balance FROM users WHERE id = $1", userID).Scan(&user.ID, &user.Name, &user.Balance)
	if err != nil {
		http.Error(w, err.Error(), http.StatusInternalServerError)
		return
	}

	// Get completed quests for user
	rows, err := db.Query("SELECT q.id, q.name, q.cost FROM completed_quests c JOIN quests q ON c.quest_id = q.id WHERE c.user_id = $1", userID)
	if err != nil {
		http.Error(w, err.Error(), http.StatusInternalServerError)
		return
	}
	defer rows.Close()

	var completedQuests []Quest
	for rows.Next() {
		var quest Quest
		err := rows.Scan(&quest.ID, &quest.Name, &quest.Cost)
		if err != nil {
			http.Error(w, err.Error(), http.StatusInternalServerError)
			return
		}
		completedQuests = append(completedQuests, quest)
	}

	userJSON, err := json.Marshal(struct {
		User           User    `json:"user"`
		CompletedQuests []Quest `json:"completed_quests"`
	}{user, completedQuests})
	if err != nil {
		http.Error(w, err.Error(), http.StatusInternalServerError)
		return
	}

	w.Header().Set("Content-Type", "application/json")
	w.Write(userJSON)
}
