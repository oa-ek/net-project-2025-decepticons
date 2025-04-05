// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

const { error, event } = require("jquery");

// Write your JavaScript code.

// Обробник кнопки "Записати гіда"
document.getElementById("addGuideBtn").addEventListener("click", function () {
    var guideId = document.getElementById("guideSelect").value;

    if (guideId != null)
    {
        fetch('/Tour/AddGuide', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ guideId: parseInt(guideId) })
        })
            .then(response => response.json())
            .then(data => {
                console.log("Гіда додано", data);
            })
            .catch(error => console.error("Помилка:", error));
    }
});

/*document.getElementById("createLocationBtn").addEventListener("click", function () {
    var location = {
        Name: document.getElementById("locationName").value,
        Latitude: parseFloat(document.getElementById("latitude").value),
        Longtitude: parseFloat(document.getElementById("longitude").value),
        Adress: document.getElementById("address").value
    };

    // Відправляємо об'єкт Location на сервер через fetch
    fetch('/Location/Create', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(location)
    })
        .then(response => response.json())
        .then(data => {
            console.log("Локація створена:", data);
            document.getElementById("locationId").value = data.location.id;
        })
        .catch(error => console.error("Помилка:", error));
});*/