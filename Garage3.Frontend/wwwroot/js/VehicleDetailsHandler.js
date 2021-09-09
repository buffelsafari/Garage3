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
            url: "/Vehicles/OnVehicleDetailsButton",
            data: { id: vehicleId },
            cache: false,
            success: function (result)
            {
                let element = document.getElementById("detailsDivId");
                let details = JSON.parse(result);

                document.getElementById("detailPlateNumber").innerHTML = details.PlateNumber;
                document.getElementById("detailModel").innerHTML = details.Model;
                document.getElementById("detailManufacturer").innerHTML = details.Manufacturer;
                document.getElementById("detailColor").innerHTML = details.Color;
                document.getElementById("detailWheels").innerHTML = details.Wheels;
                document.getElementById("detailType").innerHTML = details.Type;
                document.getElementById("detailFirstName").innerHTML = details.FirstName;
                document.getElementById("detailSurname").innerHTML = details.Surname;
                document.getElementById("detailPhoneNumber").innerHTML = details.PhoneNumber;
                document.getElementById("detailPersonalNumber").innerHTML = details.PersonalNumber;
                document.getElementById("detailMembershipType").innerHTML = details.MembershipType;

                //element.innerHTML = "";
                //element.innerHTML += "<span>PlateNumber: " + details.PlateNumber + "<span><br>";
                //element.innerHTML += "<span>Manufacturer: " + details.Manufacturer + "<span><br>";
                //element.innerHTML += "<span>Model: " + details.Model + "<span><br>";
                //element.innerHTML += "<span>NumberOfWheels: " + details.Wheels + "<span><br>";
                //element.innerHTML += "<span>VehicleType: " + details.Type + "<span><br>";
                //element.innerHTML += "<span>Owned by: <a href>" + details.OwnerName + "</a><span><br>";

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