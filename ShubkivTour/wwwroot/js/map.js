var map = L.map('map').setView([49.8397, 24.0297], 13);

// Додаємо OpenStreetMap tiles
L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    attribution: '&copy; OpenStreetMap contributors'
}).addTo(map);

// Додаємо поле пошуку
var geocoder = L.Control.geocoder({
    defaultMarkGeocode: false
}).on('markgeocode', function (e) {
    var latlng = e.geocode.center;
    var name = e.geocode.name; // Назва знайденого місця

    // Видаляємо старий маркер
    if (window.currentMarker) {
        map.removeLayer(window.currentMarker);
    }

    // Додаємо маркер
    window.currentMarker = L.marker(latlng).addTo(map)
        .bindPopup(name)
        .openPopup();

    // Оновлюємо значення у формі
    document.getElementById("locationName").value = name;
    document.getElementById("latitude").value = latlng.lat;
    document.getElementById("longitude").value = latlng.lng;
    document.getElementById("address").value = name;

    // Переміщуємо карту до нового місця
    map.setView(latlng, 15);
}).addTo(map);

// Обробник кнопки "Створити локацію"
document.getElementById("createLocationBtn").addEventListener("click", function () {
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
});