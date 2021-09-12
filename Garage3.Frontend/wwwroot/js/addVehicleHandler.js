
class AddVehicleHandler {
    #memberId;

    constructor() {
        document.querySelectorAll(".addVehicleButton").forEach(element => {

            element.addEventListener("click", (event) => this.#OnEnterModal(event));

        });

        document.getElementById("AddVehicleSaveButton").addEventListener("click", (event) => this.#OnSaveButton(event));

    }


    #OnEnterModal(event) {
        event.preventDefault();

        this.#memberId = event.target.getAttribute("data-id");

        $.ajax({
            type: "GET",
            url: "/Members/OnVehicleAddButton",
            data: { id: this.#memberId },
            cache: false,
            success: function (result) {

                let details = JSON.parse(result);


                document.getElementById("AddVehicleMemberName").innerHTML = details.Name;
                

                document.getElementById("AddVehicleFailMessage").innerHTML = "";
                console.log("result is: " + result);



            }
        });


    }
    #OnSaveButton(event) {
        //let garageId = event.target.getAttribute("data-id");
        var form = $('#__AjaxAntiForgeryForm');
        var token = $('input[name="__RequestVerificationToken"]', form).val();


        let plateNumber = document.getElementById("addVehiclePlateNumber").value;
        


        $.ajax({
            type: "POST",  // todo post?            
            url: "/Members/OnAddVehicleSave",
            data: {
                __RequestVerificationToken: token, Id: this.#memberId, plateNumber:plateNumber
            },
            cache: false,
            success: (result) => {

                let res = JSON.parse(result);
                document.getElementById("AddVehicleFailMessage").innerHTML = "is valid?:" + res.Success + " -Server:" + res.Message;
                console.log("result is: " + result)
            }
        });

    }


}