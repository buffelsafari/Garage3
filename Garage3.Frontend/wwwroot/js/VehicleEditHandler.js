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
            url:"/Vehicles/OnVehicleEditButton",
            data: { id: this.#vehicleId },
            cache: false,
            success: function (result) {

                let details = JSON.parse(result);

                document.getElementById("editPlateNumber").value = details.PlateNumber;
                document.getElementById("editModel").value = details.Model;
                document.getElementById("editManufacturer").value = details.Manufacturer;
                document.getElementById("editColor").value = details.Color;
                document.getElementById("editWheels").value = details.Wheels;
                document.getElementById("editType").value = details.Type;


                document.getElementById("editFailMessage").innerHTML = "";
                console.log("result is: " + result);
                
            }
        });
                

    }
    #OnSaveButton(event) {
        //let garageId = event.target.getAttribute("data-id");
        var form = $('#__AjaxAntiForgeryForm');
        var token = $('input[name="__RequestVerificationToken"]', form).val();

        let plateNumber=document.getElementById("editPlateNumber").value;
        let model=document.getElementById("editModel").value;
        let manufacturer=document.getElementById("editManufacturer").value;
        let color=document.getElementById("editColor").value;
        let wheels=document.getElementById("editWheels").value;
        let type=document.getElementById("editType").value;


        $.ajax({
            type: "POST",  // todo post?            
            url: "/Vehicles/OnEditSave",
            data: {
                __RequestVerificationToken: token, Id: this.#vehicleId, plateNumber: plateNumber, model: model, manufacturer: manufacturer, color:color, wheels:wheels, type:type
            },
            cache: false,
            success: (result) => {
                
                let res = JSON.parse(result);
                document.getElementById("editFailMessage").innerHTML = "is valid?:" + res.Success + " -Server:"+res.Message;
                console.log("result is: " + result)
            }
        });

    }


}


 