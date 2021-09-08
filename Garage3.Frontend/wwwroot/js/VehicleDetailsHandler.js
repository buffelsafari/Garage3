class VehicleDetailsHandler
{

    constructor()
    {
        document.querySelectorAll(".detailsButton").forEach(element => element.addEventListener("click", (event) => this.#OnEnterModal(event)));


    }

    #OnEnterModal(event)
    {
        event.preventDefault();

        let vehicleId = event.target.getAttribute("data-id");

        $.ajax({
            type: "GET",            
            url: "/Garages/OnVehicleDetailsButton",
            data: { id: vehicleId },
            cache: false,
            success: function (result)
            {
                let element = document.getElementById("detailsDivId");
                let details = JSON.parse(result);

                element.innerHTML = "";
                element.innerHTML += "<span>PlateNumber: " + details.PlateNumber + "<span><br>";
                element.innerHTML += "<span>Manufacturer: " + details.Manufacturer + "<span><br>";
                element.innerHTML += "<span>Model: " + details.Model + "<span><br>";
                element.innerHTML += "<span>NumberOfWheels: " + details.Wheels + "<span><br>";
                element.innerHTML += "<span>VehicleType: " + details.Type + "<span><br>";
                element.innerHTML += "<span>Owned by: <a href>" + details.OwnerName + "</a><span><br>";

                console.log("result is: " + result)
            }
        });

    }

}
