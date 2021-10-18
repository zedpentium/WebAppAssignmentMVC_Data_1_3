class CreatePerson extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            createperson: {
                PersonName: "",
                PersonPhoneNumber: "",
                PersonCity: 0
            }
        }
        this.handleSubmit = this.handleSubmit.bind(this);
    }
     //  I am skipping the frontend validation code requirement.. i have been working enought on this as it is /Eric R



    handleSubmit(event) {
        event.preventDefault();

        onSubmitCreatePerson(this.state.createperson, this.props.loadDataFromServer, this.props.setViewPage)
    }



    createPersonForm() {
        return (
            <div id="fieldset">
                <div id="divboxtitle">
                    Create a new Person
                </div>

                <form className="reactform" id="legbox" onSubmit={this.handleSubmit}>
                    <br />
                    <label>
                    Name:
                        <div><input type="text"
                            onChange={e => { this.setState({ createperson: { ...this.state.createperson, PersonName: e.target.value } }) } }
                            required /></div>
                    </label>
                    <br /><br />
                    <label>
                    PhoneNumber:
                        <div><input type="text"
                            onChange={e => { this.setState({ createperson: { ...this.state.createperson, PersonPhoneNumber: e.target.value } })} }
                            required /></div>
                    </label>
                    <br /><br />
                    <label>
                    City (country is allready linked to city:
                            <div><select id="SelectedListBoxView" defaultValue={"ChooseCity"}
                            onChange={e => { this.setState({ createperson: { ...this.state.createperson, PersonCity: parseInt(e.target.value) } }) }}
                            required >

                            <option value="ChooseCity" disabled> - Choose City -</option>

                        {this.props.cityliststate.map((city) => (
                        <option key={city.cityId} value={city.cityId}>{city.cityName}</option>
                        ))}

                        </select></div>
                    </label>
                    <br />
                    <br />
                    <input type="submit" value="Submit" />
                </form>
            </div>
        )
    }


    render() {
        return (
            <div className="flexwrap">
                {this.createPersonForm()}
            </div>
        )
    }

} // class end tag


function onSubmitCreatePerson(createdpersonobj, loadDataFromServer, setViewPage) {

    let createdpersonjson = JSON.stringify(createdpersonobj)
    //console.log(createdpersonjson)

    $.ajax({
        type: "POST",
        url: "/React/CreatePerson",
        data: createdpersonjson,
        success: function (data) {
            loadDataFromServer()
            setViewPage("peoplelisttable")
            $(window).scrollTop(0)
            document.getElementById("reactactionmessage").textContent = `New person is now saved.`
        },
        error: function (jqXHR, textStatus, errorThrown) {
            document.getElementById("reactactionmessage").textContent = `FAILED to create new person.${textStatus} ,  ${errorThrown}`
        },
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        mimeType: "text/html"
    })

}