// Not in USE. Would be used IF i had 3 or more CRUD Ajax Actions for react. /Eric R
function onSubmitCreatePerson(createdpersonobj) {

    let createdpersonjson = JSON.stringify(createdpersonobj)
    //console.log(createdpersonobj)
    //console.log(createdpersonjson)


    $.post("/React/CreatePerson", "application/json; charset=utf-8", 'json',  { createdpersonjson }, function (data) {
        //$("#ajaxjson").html(data);
        console.log(data);
    })
        .done(function () {
            loadDataFromServer()
            setViewPage("peoplelisttable")
            document.getElementById("reactactionmessage").textContent = `New person: ${createdpersonobj.personName} with Id: ${personobj.personId}, is now saved.`
        })
        .fail(function() {
            document.getElementById("reactactionmessage").textContent = "FAILED to create new person."
        })
        .always(function() {
            
        })
}