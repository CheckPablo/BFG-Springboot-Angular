FROM openjdk:8-jre-alpine
LABEL maintainer="khumzzz@gmail.com"
ADD target/*.jar app.jar
EXPOSE 9300
ENTRYPOINT [ "java", "-jar", "app.jar" ]
