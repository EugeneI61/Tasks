import React, { useState } from "react";
import EmployeeAddForm from "./EmployeeAdd";

export default function App() {

  const [employee, setEmployee] = useState([]);
  const [showAddNewEmployeeForm, setShowAddNewEmployeeForm] = useState(false);

  var deleteId;
  var findId;

  const handleChange = (e) => {
    deleteId = e.target.value;
  };

  const findSubmit = (e) => {
    findEmployees(findId);
  }

  const findChange = (e) => {
    findId = e.target.value;
  };

  const handleSubmit = (e) => {
    deleteEmployee(deleteId);
  }

  function findEmployees(employeeId) {
    const url = 'https://localhost:44310/api/employees/' + findId;

    fetch(url, {
      method: 'GET'
    })
      .then(response => response.json())
      .then(employeeFromServer => {
        console.log(employeeFromServer);
        setEmployee([employeeFromServer]);
      })
      .catch((error) => {
        console.log(error);
      });
  }

  function getEmployees() {
    const url = 'https://localhost:44310/api/employees';

    fetch(url, {
      method: 'GET'
    })
      .then(response => response.json())
      .then(employeeFromServer => {
        console.log(employeeFromServer);
        setEmployee(employeeFromServer);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  }
  //https://abcinblog.blogspot.com/2019/02/react-i.html
  function deleteEmployee(deleteId) {

    const url = 'https://localhost:44310/api/employees/' + Number.parseInt(deleteId);

    fetch(url, {
      method: 'DELETE'
    })
      .then(response => response.json())
      .then(responseFromServer => {
        console.log(responseFromServer);
        alert("Employee was Delete!");
      })
      .catch((error) => {
        console.log(error);
      });
  }

  const useSortableData = (items, config = null) => {
    const [sortConfig, setSortConfig] = React.useState(config);

    const sortedItems = React.useMemo(() => {
      let sortableItems = [...items];
      if (sortConfig !== null) {
        sortableItems.sort((a, b) => {
          if (a[sortConfig.key] < b[sortConfig.key]) {
            return sortConfig.direction === 'ascending' ? -1 : 1;
          }
          if (a[sortConfig.key] > b[sortConfig.key]) {
            return sortConfig.direction === 'ascending' ? 1 : -1;
          }
          return 0;
        });
      }
      return sortableItems;
    }, [items, sortConfig]);

    const requestSort = (key) => {
      let direction = 'ascending';
      if (
        sortConfig &&
        sortConfig.key === key &&
        sortConfig.direction === 'ascending'
      ) {
        direction = 'descending';
      }
      setSortConfig({ key, direction });
    };

    return { items: sortedItems, requestSort, sortConfig };
  };

  return (
    <div className="container">
      <div className="row min-vh-100">
        <div className="col d-flex flex-column justify-content-center align-items-center">

          {showAddNewEmployeeForm === false && (
            <div>
              <h1>Task8</h1>
              <div className="mt-5">
                <button onClick={getEmployees} className="btn btn-dark btn-lg w-100">Get Employees from Server</button>
              </div>
            </div>
          )}
          {(showAddNewEmployeeForm && employee.length > 5) && Overflow()}

          {(employee.length > 0 && showAddNewEmployeeForm === false) && RenderTable()}

          {showAddNewEmployeeForm && <EmployeeAddForm onEmployeeAdded={onEmployeeAdded} />}
        </div>
      </div>
    </div>
  );

  function RenderTable(props) {
    const { items, requestSort, sortConfig } = useSortableData(props.employee);
    const getClassNamesFor = (name) => {
      if (!sortConfig) {
        return;
      }
      return sortConfig.key === name ? sortConfig.direction : undefined;
    };
    return (
      <div className="table-responsive">
        <input className="form-control mt-4" type="text" placeholder="Filter" id="search-text" onKeyUp={tableSearch}></input>
        <table className="table" id="info-table">
          <thead>
            <tr>
              <th ><button type="button" onClick={() => requestSort('employeeId')}
                className={getClassNamesFor('employeeId')}>Id</button></th>
              <th ><button type="button" onClick={() => requestSort('employeeName')}
                className={getClassNamesFor('employeeName')}>EmployeeName </button></th>
              <th ><button type="button" onClick={() => requestSort('employeeAge')}
                className={getClassNamesFor('employeeAge')}>EmployeeAge</button></th>
              <th ><button type="button" onClick={() => requestSort('car')}
                className={getClassNamesFor('car')}>Car</button></th>
              <th ><button type="button" onClick={() => requestSort('recordId')}
                className={getClassNamesFor('recordId')}>RecordId</button></th>
            </tr>
          </thead>
          <tbody>
            {employee.map((employee) => (
              <tr key={employee.employeeId}>
                <th scope="row">{employee.employeeId}</th>
                <td>{employee.employeeName}</td>
                <td>{employee.employeeAge}</td>
                <td>{employee.car}</td>
                <td>{employee.recordId}</td>
              </tr>
            ))}
          </tbody>
        </table>
        <button onClick={() => setShowAddNewEmployeeForm(true)} className="btn btn-secondary btn-lg w-100 mt-4">Add New Employee</button>
        <button onClick={() => setEmployee([])} className="btn btn-secondary btn-lg w-100 mt-4">Empty React Array</button>
        <div className='mt-4'>
          <label className='h3 form-label'>Input Id for delete!</label>
          <input value={deleteId} name="deleteId" type="number" className='form-control' onChange={handleChange} />
          <button onClick={handleSubmit} className="btn btn-secondary btn-lg w-100 mt-4">Delete Employee</button>
        </div>
        <div className='mt-4'>
          <label className='h3 form-label'>Input Id for find!</label>
          <input value={findId} name="findId" type="number" className='form-control' onChange={findChange} />
          <button onClick={findSubmit} className="btn btn-secondary btn-lg w-100 mt-4">Find</button>
        </div>
      </div>
    );
  };


    function onEmployeeAdded(addedEmployee) {
      setShowAddNewEmployeeForm(false);
      if (addedEmployee === null) {
        return;
      }
      alert("Post Success!");
      getEmployees();
    }

    function Overflow() {
      setShowAddNewEmployeeForm(false);
      alert("Data is Overflow!");
    }
    function tableSearch() {
      var phrase = document.getElementById('search-text');
      var table = document.getElementById('info-table');
      var regPhrase = new RegExp(phrase.value, 'i');
      var flag = false;
      for (var i = 1; i < table.rows.length; i++) {
        flag = false;
        for (var j = table.rows[i].cells.length - 1; j >= 0; j--) {
          flag = regPhrase.test(table.rows[i].cells[j].innerHTML);
          if (flag) break;
        }
        if (flag) {
          table.rows[i].style.display = "";
        } else {
          table.rows[i].style.display = "none";
        }
      }
    }

  }

