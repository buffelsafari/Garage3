class MemberDetailsHandler {

    constructor() {
        document.querySelectorAll(".detailsButton").forEach(element => element.addEventListener("click", (event) => this.#OnEnterModal(event)));


    }

    #OnEnterModal(event) {
        event.preventDefault();

        let vehicleId = event.target.getAttribute("data-id");

        $.ajax({
            type: "GET",
            url: "/Members/OnMemberDetailsButton",
            data: { id: vehicleId },
            cache: false,
            success: function (result) {
                let element = document.getElementById("detailsDivId");
                let details = JSON.parse(result);
                                
                document.getElementById("memberDetailFirstName").innerHTML = details.FirstName;
                document.getElementById("memberDetailSurname").innerHTML = details.Surname;
                document.getElementById("memberDetailPhoneNumber").innerHTML = details.PhoneNumber;
                document.getElementById("memberDetailPersonalNumber").innerHTML = details.PersonalNumber;
                document.getElementById("memberDetailMembershipType").innerHTML = details.MembershipType;

               

                console.log("result is: " + result)
            }
        });

    }

}


        //public string PlateNumber { get; set; }
        //public string Model { get; set; }
        //public string Manufacturer { get; set; }
        //public string Color { get; set; }
        //public int Wheels { get; set; }
        //public string Type { get; set; }

        //public int OwnerId { get; set; }
        //public string FirstName { get; set; }
        //public string Surname { get; set; }
        //public string PhoneNumber { get; set; }
        //public string PersonalNumber { get; set; }
        //public string MembershipType { get; set; }