# Используем образ Golang для сборки приложения
FROM golang:latest AS builder

# Устанавливаем рабочую директорию внутри контейнера
WORKDIR /app

# Копируем содержимое текущей директории внутрь контейнера
COPY . .

# Собираем приложение внутри контейнера
RUN go mod download
RUN CGO_ENABLED=0 GOOS=linux go build -o app .

# Используем образ Alpine Linux в качестве базового для уменьшения размера контейнера
FROM alpine:latest  

# Устанавливаем необходимые зависимости
RUN apk --no-cache add ca-certificates

# Копируем бинарный файл из билд-стейджа в образ
COPY --from=builder /app/app /usr/local/bin/app

# Устанавливаем переменную окружения PORT
ENV PORT=8080

# Экспортируем порт 8080
EXPOSE 8080

# Запускаем приложение
CMD ["app"]
