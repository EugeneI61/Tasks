import React, { useState } from "react";
import EmployeeAddForm from "./EmployeeAdd";

export default function App() {

  const [employee, setEmployee] = useState([]);
  const [showAddNewEmployeeForm, setShowAddNewEmployeeForm] = useState(false);

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

  return (
    <div className="container">
      <div className="row min-vh-100">
        <div className="col d-flex flex-column justify-content-center align-items-center">

          {showAddNewEmployeeForm === false && (
            <div>
              <h1>Task8</h1>
              <div className="mt-5">
                <button onClick={getEmployees} className="btn btn-dark btn-lg w-100">Get Employees from Server</button>
                <button onClick={() => setShowAddNewEmployeeForm(true)} className="btn btn-secondary btn-lg w-100 mt-4">Add New Employee</button>
              </div>
            </div>
          )}

          {(employee.length > 0 && showAddNewEmployeeForm === false) && renderTable()}

          {showAddNewEmployeeForm && <EmployeeAddForm onEmployeeAdded={onEmployeeAdded} />}
        </div>
      </div>
    </div>
  );


  function renderTable() {
    return (
      <div className="table-responsive mt-5">
        <table className="table table-bordered border-dark">
          <thead>
            <tr>
              <th scope="col">EmployeeId</th>
              <th scope="col">EmployeeName</th>
              <th scope="col">EmployeeAge</th>
              <th scope="col">Car</th>
              <th scope="col">RecordId</th>
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

        <button onClick={() => setEmployee([])} className="btn btn-secondary btn-lg w-100">Empty React Array</button>
      </div>
    );
  }

  function onEmployeeAdded(addedEmployee) {

    setShowAddNewEmployeeForm(false);

    if (addedEmployee === null) {
      return;
    }

    alert("Post Success!");

    getEmployees();
  }
}
