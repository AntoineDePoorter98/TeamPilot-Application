docker build -t teampilot .
docker run -d -p 8080:80 --name teampilot teampilot