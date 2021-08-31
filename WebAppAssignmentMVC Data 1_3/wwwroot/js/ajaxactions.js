function getAllPeople() {
    $.get("/Ajax/AllPeopleList", null, function (data) {
        $("#peopleviewlist").html(data);
    });
    document.getElementById("jsmessage").textContent = "List of All People fetched.";
}

function getPersonByID() {
    var idNr = "document.getElementById('IdInput').value";
    $.post("/Ajax/FindPersonById", idNr, function (data) {
        $("#peopleviewlist").html(data);
    });
    document.getElementById("jsmessage").textContent = "One Person fetched by ID.";
}

function deletePersonById() {
    var idNr = document.getElementById('IdInput').value;

    $.post("/Ajax/DeletePersonById", function (data, success) {
        $("#peopleviewlist").html(data, success);
    });
    document.getElementById("jsmessage").textContent = "One Person Deleted by ID.";
}


function displayMessage(msg) {
    document.getElementById(jsmessage).textContent = msg;
}



function displayError(error) {
    document.getElementById("error").innerHTML = JSON.stringify(error);
}
