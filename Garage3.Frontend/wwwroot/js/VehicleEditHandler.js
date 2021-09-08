class VehicleEditHandler {
    #vehicleId;

    constructor() {
        document.querySelectorAll(".editButton").forEach(element => {

            element.addEventListener("click", (event) => this.#OnEnterModal(event));

        });

        document.getElementById("EditSaveButton").addEventListener("click", (event) => this.#OnSaveButton(event));

    }


    #OnEnterModal(event) {
        event.preventDefault();

        this.#vehicleId = event.target.getAttribute("data-id");

        $.ajax({
            type: "GET",            
            url:"/Garages/OnVehicleEditButton",
            data: { id: this.#vehicleId },
            cache: false,
            success: function (result) {

                let details = JSON.parse(result);

                document.getElementById("editPlateNumber").value = details.PlateNumber;
                document.getElementById("editModel").value = details.Model;
                document.getElementById("editManufacturer").value = details.Manufacturer;
                document.getElementById("editWheels").value = details.Wheels;
                document.getElementById("editType").value = details.Type;

                console.log("result is: " + result)
            }
        });


    }
    #OnSaveButton(event) {
        //let garageId = event.target.getAttribute("data-id");
        var form = $('#__AjaxAntiForgeryForm');
        var token = $('input[name="__RequestVerificationToken"]', form).val();


        $.ajax({
            type: "POST",  // todo post?            
            url: "/Garages/OnEditSave",
            data: {
                __RequestVerificationToken: token, Id: this.#vehicleId, Item1: "hello", Item2: "world"
            },
            cache: false,
            success: (result) => {
                let element = document.getElementById("editDivId");
                let details = JSON.parse(result);


                element.innerHTML += "is valid?:" + details.Success + "<br>";

                console.log("result is: " + result)
            }
        });

    }






}