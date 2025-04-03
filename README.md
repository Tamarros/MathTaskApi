# MathTaskApi - מדריך לפריסה עם Docker

---

1. הרץ את פקודת הבנייה:

```bash
docker build -t mathtaskapi .
```

---

2. הרצת  פקודת הבנייה:

```bash
docker run -d -p 8080:80 --name mathtaskapi_container mathtaskapi
```
פתחו את:

```
http://localhost:8080/swagger
```

## פתרון בעיות

-  הרץ `docker ps` כדי לבדוק אם הקונטיינר פעיל
-  בדוק לוגים:

```bash
docker logs mathtaskapi_container
```

-  ודא  שהפניייה אל `http://localhost:8080/swagger` בדפדפן

---

## הערות
- הפרויקט משתמש בחבילת NuGet מקומית (`IO.Models.1.0.0.nupkg`). ודא שהיא קיימת **לפני** בניית הדוקר
- ניתן לגשת לפרויקט https://github.com/Tamarros/IO.Swagger וליצור מחדש את הנוגט ולהתקין לוקאלי מחדש
