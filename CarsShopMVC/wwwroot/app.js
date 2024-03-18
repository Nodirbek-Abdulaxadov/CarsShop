function ChangeColor(colorId) {
    event.preventDefault();
    $.ajax({
        url: "/Home/GetImages?colorId=" + colorId,
        type: "GET",
        data: {},
        success: function (data) {
            UpdateCarousel(data)
        }
    });

    var input = document.getElementById("colorId");
    input.value = colorId;
}

function UpdateCarousel(data) {

    var items = data;
    console.log(items);

    var carouselInner = document.getElementsByClassName("carousel-inner")[0];
    carouselInner.innerHTML = "";
    for (let i = 0; i < items.length; i++) {
        var url = 'https://localhost:7187/'+items[i].replace("~", "");
        if (i == 0) {
            var div = `
                    <div class="carousel-item active" >
                        <img src="${url}" style = "object-fit: contain" height = "400" width = "400" asp-append-version="true" class="d-block w-100" alt = "..." >
                    </div>
                `;
            carouselInner.innerHTML += div;
        }
        else {
            var div = `
                    <div class="carousel-item" >
                        <img src="${url}" style = "object-fit: contain" height = "400" width = "600" asp-append-version="true" class="d-block w-100" alt = "..." >
                    </div>
                    `;
            carouselInner.innerHTML += div;
        }
    }
}

function order(carId) {
    var input = document.getElementById("colorId");
    var colorId = input.value;
    window.location.href = "/Home/Order?carId=" + carId + "&colorId=" + colorId;
 }