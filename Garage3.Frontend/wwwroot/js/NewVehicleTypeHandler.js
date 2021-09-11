class NewVehicleTypeHandler {
    #currentGarageId;


    constructor() {
        document.getElementById("newVehicleTypeButton").addEventListener("click", (event) => this.#OnEnterModal(event));

        document.getElementById("newVehicleTypeSaveButton").addEventListener("click", (event) => this.#OnSaveButton(event));
    }

    #OnEnterModal(event) {
        this.#currentGarageId = event.target.getAttribute("data-id");

        $.ajax({
            type: "GET",            
            url:"/Garages/OnNewVehicleTypeButton",
            data: { id: this.#currentGarageId },
            cache: false,
            success: (result) => {
                let element = document.getElementById("newVehicleTypeDivId");
                let details = JSON.parse(result);

                document.getElementById("NewVehicleTypeGarageName").innerHTML = details.GarageName;
                //element.innerHTML = "";
                element.innerHTML += "Garage id:" + details.GarageId + "<br>";
                element.innerHTML += details.GarageName;
                

                console.log("result is: " + result)

               


            }
        });

    }

    #OnSaveButton(event) {
        //let garageId = event.target.getAttribute("data-id");
        var form = $('#__AjaxAntiForgeryForm');
        var token = $('input[name="__RequestVerificationToken"]', form).val();

        console.log(this.#currentGarageId);

        let name = document.getElementById("NewVehicleTypeName").value;
        let requiredParkingLots = document.getElementById("NewVehicleTypeReqParkingLots").value;
        let basicFee = document.getElementById("NewVehicleTypeBasicFee").value;

        $.ajax({
            type: "POST",           
            url: "/Garages/OnNewVehicleTypeSave",
            data: {
                
                __RequestVerificationToken: token, Id: this.#currentGarageId, name: name, requiredParkingLots: requiredParkingLots,basicFee:basicFee
            },
            cache: false,
            success: (result) => {
                
                let details = JSON.parse(result);

                document.getElementById("newVehicletypeFailMessage").innerHTML = "is valid?:" + details.Success + "<br>";
                

                console.log("result is: " + result)
            }
        });

    }


}