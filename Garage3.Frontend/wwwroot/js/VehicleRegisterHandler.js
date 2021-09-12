class VehicleRegisterHandler {
    

    constructor() {


        
        document.getElementById("registerVehicle").addEventListener("click", (event) => this.#OnEnterModal(event));
        document.getElementById("RegisterSaveButton").addEventListener("click", (event) => this.#OnSaveButton(event));

    }


    #OnEnterModal(event) {
        event.preventDefault();

        


    }
    #OnSaveButton(event) {
        //let garageId = event.target.getAttribute("data-id");
        var form = $('#__AjaxAntiForgeryForm');
        var token = $('input[name="__RequestVerificationToken"]', form).val();

        let plateNumber = document.getElementById("registerPlateNumber").value;
        let model = document.getElementById("registerModel").value;
        let manufacturer = document.getElementById("registerManufacturer").value;
        let color = document.getElementById("registerColor").value;
        let wheels = document.getElementById("registerWheels").value;
        let type = document.getElementById("registerType").value;


        $.ajax({
            type: "POST",  // todo post?            
            url: "/Vehicles/OnRegisterSave",
            data: {
                __RequestVerificationToken: token, plateNumber: plateNumber, model: model, manufacturer: manufacturer, color: color, wheels: wheels, type: type
            },
            cache: false,
            success: (result) => {

                let res = JSON.parse(result);
                document.getElementById("registerFailMessage").innerHTML = "is valid?:" + res.Success + " -Server:" + res.Message;
                console.log("result is: " + result)
            }
        });

    }


}