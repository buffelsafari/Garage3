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

                element.innerHTML = "";
                element.innerHTML += "Garage id:" + details.GarageId + "<br>";
                element.innerHTML += details.item1;
                element.innerHTML += details.item2;
                element.innerHTML += details.item3;

                console.log("result is: " + result)
            }
        });

    }

    #OnSaveButton(event) {
        //let garageId = event.target.getAttribute("data-id");
        var form = $('#__AjaxAntiForgeryForm');
        var token = $('input[name="__RequestVerificationToken"]', form).val();

        console.log(this.#currentGarageId);

        $.ajax({
            type: "POST",           
            url: "/Garages/OnNewVehicleTypeSave",
            data: {
                
                __RequestVerificationToken: token, Id: this.#currentGarageId, Item1: "hello", Item2: "world"
            },
            cache: false,
            success: (result) => {
                let element = document.getElementById("newVehicleTypeDivId");
                let details = JSON.parse(result);


                element.innerHTML += "is valid?:" + details.Success + "<br>";

                console.log("result is: " + result)
            }
        });

    }


}