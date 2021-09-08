class CheckoutHandler {
    #vehicleId

    constructor() {
        document.querySelectorAll(".checkoutButton").forEach(element => {

            element.addEventListener("click", (event) => this.#OnEnterModal(event));

        });

        document.getElementById("CheckoutSaveButton").addEventListener("click", (event) => this.#OnCheckoutButton(event));

    }

    #OnEnterModal(event) {
        event.preventDefault();

        this.#vehicleId = event.target.getAttribute("data-id");

        $.ajax({
            type: "GET",            
            url: "/Garages/OnVehicleCheckoutButton",
            data: { id: this.#vehicleId },
            cache: false,
            success: function (result) {
                let element = document.getElementById("checkoutDivId");
                let details = JSON.parse(result);

                element.innerHTML = "";
                element.innerHTML += "Vehicle id:" + details.VehicleId + "<br>";
                element.innerHTML += details.item1;
                element.innerHTML += details.item2;
                element.innerHTML += details.item3;

                console.log("result is: " + result)
            }
        });

    }

    #OnCheckoutButton(event) {
        //let garageId = event.target.getAttribute("data-id");
        var form = $('#__AjaxAntiForgeryForm');
        var token = $('input[name="__RequestVerificationToken"]', form).val();


        $.ajax({
            type: "POST",             
            url: "/Garages/OnCheckout",
            data: {
                __RequestVerificationToken: token, Id: this.#vehicleId, Item1: "hello", Item2: "world"
            },
            cache: false,
            success: (result) => {
                let element = document.getElementById("checkoutDivId");
                let details = JSON.parse(result);


                element.innerHTML += "is valid?:" + details.Success + "<br>";

                console.log("result is: " + result)
            }
        });

    }

}