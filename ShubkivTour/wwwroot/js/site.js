// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

const { error, event } = require("jquery");

// Write your JavaScript code.


document.getElementById("addGuideBtn").addEventListener("click", function () {
    var guideId = document.getElementById("guideSelect").value;

    fetch('/Tour/AddGuide', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(guideId) // Передаємо тільки guideId
    })
        .then(response => response.json())
        .then(data => {
            console.log("Гіда додано:", data);

            // Додаємо гіда до списку на сторінці
            var listItem = document.createElement("li");
            listItem.textContent = data.guide.Name; // Покажемо ім'я гіда
            document.getElementById("guidsInTourList").appendChild(listItem);

            // Можливо, ви хочете додати ID гіда в прихований input
            document.getElementById("guideId").value = guideId;
        })
        .catch(error => console.error("Помилка:", error));
});
