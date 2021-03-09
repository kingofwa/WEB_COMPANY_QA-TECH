
function initMap() {
        const uluru = { lat: 20.999370, lng: 105.824710 };//location addred
        const map = new google.maps.Map(document.getElementById("canavas_map"), {
            zoom: 16,
            center: uluru,
        });
        const contentString = $("#idContactDetails").val();

        const infowindow = new google.maps.InfoWindow({
            content: contentString,
        });
        const marker = new google.maps.Marker({
            position: uluru,
            map,
            title: "Uluru (Ayers Rock)",
        });
        marker.addListener("click", () => {
        });
        infowindow.open(map, marker);
    }

