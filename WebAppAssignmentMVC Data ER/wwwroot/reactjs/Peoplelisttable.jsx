class Peoplelisttable extends React.Component {
    constructor(props) {
        super(props)
    }


    render() {
        return (
           <div>
                <br/>
                <h4 id='title'>React Peoplelist shown in Table.</h4>
                <p>(click on tablehead "PersonID" or "Name" to sort them ascending)</p>
                <br/>                
                <RenderTable personlistdatastate={this.props.personlistdatastate} setPersonobjstate={this.props.setPersonobjstate} setViewPage={this.props.setViewPage} />
           </div>
        )
    }

} // class end tag


const RenderTable = ({ personlistdatastate, setPersonobjstate, setViewPage }) => {
    //React.useMemo(() => {
    const [sortedField, setSortedField] = React.useState("")
    const [sortedFieldIdArrow, setSortedFieldIdArrow] = React.useState("↓")
    const [sortedFieldNameArrow, setSortedFieldNameArrow] = React.useState("")

        let sortedProducts = personlistdatastate
        if (sortedField !== "") {
            sortedProducts.sort((first, second) => {
                if (first[sortedField] < second[sortedField]) {
                    return -1;
                }
                if (first[sortedField] > second[sortedField]) {
                    return 1;
                }

                return 0;
            });
        } // end if
    //}, [personlistdatastate, sortedField])  // end useMemo

    sortList = (column = "") => {
        setSortedField(column)

        if (column == "personId") {
            setSortedFieldIdArrow("↓")
            setSortedFieldNameArrow("")
        }
        if (column == "personName") {
            setSortedFieldNameArrow("↓")
            setSortedFieldIdArrow("")
        }
    }


    return (
        <table id="reactpeoplelisttable">
            <thead>
                <tr className="bg-dark text-light">
                    <th>
                        <button type="button" onClick={() => sortList("personId")}>
                            PersonID {sortedFieldIdArrow}
                        </button>
                    </th>
                    <th>
                        <button type="button" onClick={() => sortList("personName")}>
                            Name {sortedFieldNameArrow}
                        </button>
                    </th>
                    <th>PhoneNumber</th>
                    <th>Option</th>
                </tr>
            </thead>
            <tbody>
                {sortedProducts.map(personobj => (
                    <tr key={personobj.personId}>
                        <td>{personobj.personId}</td>
                        <td>{personobj.personName}</td>
                        <td>{personobj.personPhoneNumber}</td>
                        <td><button id="optionBtnGreen" onClick={() => personDetailsClick(personobj, setPersonobjstate, setViewPage)}>Edit</button></td>
                    </tr>
                ))}
            </tbody>
        </table>
    ) //end return

} // end renderTable


function personDetailsClick(personobj, setPersonobjstate, setViewPage) {
    console.log(personobj.personId)
    setPersonobjstate(personobj)
    setViewPage("persondetails")
};













/*
old code for print in brower test
function printClick() {
    window.print()
}

<td><button id="optionBtnGreen" onClick={() => printClick()}>Print</button></td>
*/