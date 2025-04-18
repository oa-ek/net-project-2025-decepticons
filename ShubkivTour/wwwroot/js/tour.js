
document.getElementById("addGuideBtn").addEventListener("click", function () {
	var guideId = document.getElementById("guideSelect").value;

	fetch('/Tour/AddGuide', {
		method: 'POST',
		headers: { 'Content-Type': 'application/json' },
		body: JSON.stringify(guideId)
	})
		.then(response => response.json())
		.then(data => {
			console.log("Гіда додано:", data);

			if (data.success) {
				// Додати гіда до списку на сторінці
				var listItem = document.createElement("li");
				listItem.textContent = data.guide.Name;
				document.getElementById("guidsInTourList").appendChild(listItem);

				// Додати гіда до прихованого списку
				var addedGuides = JSON.parse(localStorage.getItem('addedGuides')) || [];
				addedGuides.push(data.guide);
				localStorage.setItem('addedGuides', JSON.stringify(addedGuides));

				// Оновити випадаючий список, щоб не показувати вже доданих гідів
				updateGuideSelectList();
			}
		})
		.catch(error => console.error("Помилка:", error));
});

function updateGuideSelectList() {
	var addedGuides = JSON.parse(localStorage.getItem('addedGuides')) || [];
	var guideSelect = document.getElementById("guideSelect");

	// Оновлюємо випадаючий список, видаляючи вже доданих гідів
	Array.from(guideSelect.options).forEach(option => {
		var optionGuideId = option.value;
		if (addedGuides.some(guide => guide.Id == optionGuideId)) {
			option.disabled = true;
		} else {
			option.disabled = false;
		}
	});
}

// Викликаємо updateGuideSelectList при завантаженні сторінки
window.onload = function () {
	updateGuideSelectList();
};
