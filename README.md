# MathTaskApi - מדריך לפריסה עם Docker

מדריך זה מסביר כיצד לבנות ולהריץ את פרויקט `MathTaskApi` באמצעות Docker ו־Docker Compose.

---

## ✅ דרישות מקדימות

1. **Windows 10**
2. **Visual Studio 2022** (עם תמיכה ב־Docker)
3. **Docker Desktop** מותקן ורץ
4. אופציונלי: Docker Compose (לתמיכה במספר קונטיינרים)

---

## שלב 1: יצירת Docker Image

1. פתחי שורת פקודה (PowerShell או CMD)
2. נווטי לתיקיית הפרויקט:

```bash
cd C:\Users\<your_username>\source\repos\MathTaskApi\MathTaskApi
```

3. הריצי את פקודת הבנייה:

```bash
docker build -t mathtaskapi .
```

---

## שלב 2: הרצת הקונטיינר

```bash
docker run -d -p 8080:80 --name mathtaskapi_container mathtaskapi
```

זה יחשוף את הממשק בכתובת:

```
http://localhost:8080
```

פתחי את:

```
http://localhost:8080/swagger
```

> אם זה לא נטען, ודאי ש־Docker רץ, והפורט פתוח.

---

## שלב 3: עצירת הקונטיינר

```bash
docker stop mathtaskapi_container
```

## שלב 4: הרצת הקונטיינר מחדש

```bash
docker start mathtaskapi_container
```

---


## פתרון בעיות

- ✅ הריצי `docker ps` כדי לבדוק אם הקונטיינר פעיל
- ✅ בדקי לוגים:

```bash
docker logs mathtaskapi_container
```

- ✅ ודאי שאת פונה אל `http://localhost:8080/swagger` בדפדפן

---

## הערות
- הפרויקט משתמש בחבילת NuGet מקומית (`IO.Models.1.0.0.nupkg`). ודאי שהיא משוחזרת **לפני** בניית הדוקר, או העבירי את הקובץ לתיקיית הפרויקט כך ש־Docker יוכל לגשת אליו במהלך הבנייה.

