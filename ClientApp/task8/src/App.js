import React, { Component } from 'react';
import Loader from './Loader/Loader';
import Table from './Table/Table';
import _, { get } from 'lodash';
import TableSearch from './TableSearch/TableSearch';
import EmployeeAddForm from './EmployeeAdd/EmployeeAdd';
import DeleteEmployeeForm from './DeleteEmployee/DeleteEmployee';



class App extends Component {

  state = {
    isLoading: true,
    search: '',
    data: [],
    sort: 'asc',  // 'desc'
    sortField: 'id',
    currentPage: 0,
    showAddNewEmployeeForm: false,
    setShowAddNewEmployeeForm: false
  }

  async componentDidMount() {
    const response = await fetch('https://localhost:44310/api/employees/')
    const data = await response.json()

    this.setState({
      isLoading: false,
      data: _.orderBy(data, this.state.sortField, this.state.sort)
    })
  }

  searchHandler = search => (
    this.setState({ search })
  )

  onSort = sortField => {

    const cloneData = this.state.data.concat();
    const sortType = this.state.sort === 'asc' ? 'desc' : 'asc';
    const orderedData = _.orderBy(cloneData, sortField, sortType);

    this.setState({
      data: orderedData,
      sort: sortType,
      sortField
    })
  }

  
  render() {
    const pageSize = 50;
    const filteredData = this.getFilteredData()
    const displayData = _.chunk(filteredData, pageSize)[this.state.currentPage]

    return (
      <div className="container">
        {
          this.state.isLoading
            ? <Loader />
            : <React.Fragment>
              <div className="flex-row">
                <div className="flex-large">
                  <EmployeeAddForm />
                </div>
                <div className="flex-large">
                  <DeleteEmployeeForm />
                </div>
                <TableSearch onSearch={this.searchHandler} />
                <Table
                  data={displayData}
                  onSort={this.onSort}
                  sort={this.state.sort}
                  sortField={this.state.sortField}
                  forcePage={this.state.currentPage}
                />
              </div>
            </React.Fragment>
        }
      </div>
    );
  }

  getFilteredData() {
    const { data, search } = this.state

    if (!search) {
      return data
    }

    var result = data.filter(item => {
      return (
        item["employeeName"].toLowerCase().includes(search.toLowerCase()) ||
        item["employeeAge"].toString().toLowerCase().includes(search.toLowerCase()) ||
        item["car"].toString().toLowerCase().includes(search.toLowerCase()) ||
        item["recordId"].toString().toLowerCase().includes(search.toLowerCase())
      );
    });
    if (!result.length) {
      result = this.state.data
    }
    return result
  }
}
export default App;
