class Index extends React.Component {

    constructor(props) {
        super(props)
        //this.setViewPage = this.setViewPage.bind(this)  dont need to bind when doing arrows jsx below /ER
        //this.setPersonobjstate = this.setPersonobjstate.bind(this)
        this.state = {
            personliststate: [],
            cityliststate: [],
            view: "peoplelisttable",
            personobj: [],
            peoplelistapiurl: "/Reactjsonpersonlist",
            citylistapiurl: "/Reactjsoncitylist"
        }
    }



    loadDataFromServer = () => {
       const xhr = new XMLHttpRequest();
        xhr.open('get', this.state.peoplelistapiurl, true)
        xhr.onload = () => {
            const personlist = JSON.parse(xhr.responseText)
            this.setState({ personliststate: personlist })
        }
        xhr.send()

        const xhr2 = new XMLHttpRequest();
        xhr2.open('get', this.state.citylistapiurl, true)
        xhr2.onload = () => {
            const citylist = JSON.parse(xhr2.responseText)
            this.setState({ cityliststate: citylist })
        }
        xhr2.send()

        /* axios.get(this.state.peoplelistapiurl)
     .then(dbdata => {
         this.setState({ personlistdata: dbdata });
     })
     .catch(e => {
         console.log(e)
     });*/
    }


    componentDidMount = () => {
        this.loadDataFromServer();
        window.setInterval(this.loadDataFromServer(), this.props.pollInterval);
    }

    setViewPage = (page = this.state.view) => {
        this.setState({ view: page })
    }

    setPersonobjstate = (person = this.state.personobj) => {
        this.setState({ personobj: person })
    }


    render() {
        return (
        <div>
                <ChangeView
                    viewpagestate={this.state.view}
                    personliststate={this.state.personliststate}
                    cityliststate={this.state.cityliststate}
                    setViewPage={this.setViewPage}
                    loadDataFromServer={this.loadDataFromServer}
                    setPersonobjstate={this.setPersonobjstate}
                    personobj={this.state.personobj}
                />
        </div>
        )
    }

} // class end tag

const ChangeView = ({ viewpagestate, personliststate, cityliststate, setViewPage, loadDataFromServer, setPersonobjstate, personobj }) => {
    return (
        <SwitchComponents active={viewpagestate}>
            <Peoplelisttable
                name="peoplelisttable"
                personliststate={personliststate}
                setViewPage={setViewPage}
                setPersonobjstate={setPersonobjstate}
            />
            <Persondetails
                name="persondetails"
                personliststate={personliststate}
                setViewPage={setViewPage}
                loadDataFromServer={loadDataFromServer}
                personobj={personobj}
            />
            <CreatePerson
                name="createperson"
                cityliststate={cityliststate}
                setViewPage={setViewPage}
                loadDataFromServer={loadDataFromServer}
                personobj={personobj}
            />
        </SwitchComponents>
    )

}



ReactDOM.render(<Index pollInterval={2000} />, document.getElementById('reactdivcontainer'))
