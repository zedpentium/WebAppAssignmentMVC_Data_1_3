﻿class Index extends React.Component {

    constructor(props) {
        super(props)
        //this.setViewPage = this.setViewPage.bind(this)  dont need to bind when doing arrows jsx below /ER
        //this.setPersonobjstate = this.setPersonobjstate.bind(this)
        this.state = {
            personlistdata: [],
            view: "peoplelisttable",
            personobj: [],
            peoplelistapiurl: "/Reactjson"
        }
    }



    loadDataFromServer = () => {
       /* axios.get(this.state.peoplelistapiurl)
            .then(dbdata => {
                this.setState({ personlistdata: dbdata });
            })
            .catch(e => {
                console.log(e)
            });*/
       const xhr = new XMLHttpRequest();
        xhr.open('get', this.state.peoplelistapiurl, true)
        xhr.onload = () => {
            const data = JSON.parse(xhr.responseText)
            this.setState({ personlistdata: data })
        }
        xhr.send()
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
                    personlistdatastate={this.state.personlistdata}
                    setViewPage={this.setViewPage}
                    loadDataFromServer={this.loadDataFromServer}
                    setPersonobjstate={this.setPersonobjstate}
                    personobj={this.state.personobj}
                />
        </div>
        )
    }

} // class end tag

const ChangeView = ({ viewpagestate, personlistdatastate, setViewPage, loadDataFromServer, setPersonobjstate, personobj }) => {
    return (
        <SwitchComponents active={viewpagestate}>
            <Peoplelisttable
                name="peoplelisttable"
                personlistdatastate={personlistdatastate}
                setViewPage={setViewPage}
                setPersonobjstate={setPersonobjstate}
            />
            <Persondetails
                name="persondetails"
                personlistdatastate={personlistdatastate}
                setViewPage={setViewPage}
                loadDataFromServer={loadDataFromServer}
                personobj={personobj}
            />
        </SwitchComponents>
    )

}



ReactDOM.render(<Index pollInterval={2000} />, document.getElementById('reactdivcontainer'))
