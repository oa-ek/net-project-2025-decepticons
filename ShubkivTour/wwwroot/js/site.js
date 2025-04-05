// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

const { error, event } = require("jquery");

// Write your JavaScript code.


/*function updateEventList(events) {
    var eventListDiv = document.getElementById('eventsList');
    eventListDiv.innerHTML = '';

    // Додаємо нові події до списку
    events.forEach(event => {
        var eventElement = document.createElement('li');
        eventElement.innerHTML = `${event.Name} - ${event.Description} (${event.Time})`;
        eventsListDiv.appendChild(eventElement);
    });
}*/

/*// Обробник кнопки "Створити івент"
document.getElementById("createLocationBtn").addEventListener("click", function () {
    var event = {
        Name: document.getElementById("eventName").value,
        Description: document.getElementById("eventDescription").value,
        Time: document.getElementById("eventTime").value,
        LocationId: document.getElementById("locationId").value
    };

    // Відправляємо об'єкт Event на сервер через fetch
    fetch('/Program/AddEvent', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(event)
    })
        .then(response => response.json())
        .then(data => {
            console.log("Подія створена:", data);
            document.getElementById("eventId").value = data.event.id;
        })
        .catch(error => console.error("Помилка:", error));
});
*/