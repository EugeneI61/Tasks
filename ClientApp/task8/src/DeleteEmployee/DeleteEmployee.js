import React from 'react'

const DeleteEmployeeForm = props => {

  let deleteId;

  function deleteEmployee(deleteId) {

    const url = 'https://localhost:44310/api/employees/' + Number.parseInt(deleteId);

    fetch(url, {
      method: 'DELETE'
    })
      .then(response => response.json())
      .then(responseFromServer => {
        console.log(responseFromServer);
        
      })
      .catch((error) => {
        console.log(error);
      });
  }
  const handleChange = (e) => {
    deleteId = e.target.value;
  };
  const handleSubmit = (e) => {
    alert("Employee was Delete!");
    deleteEmployee(deleteId);
  }
    return (
        <form className='w-50 px-5'>
        <div className='mt-4'>
          <label className='h3 form-label'>Input Id for delete!</label>
          <input value={deleteId} name="deleteId" type="number" className='form-control' onChange={handleChange} />
          <button onClick={handleSubmit} className="btn btn-secondary btn-lg w-100 mt-4">Delete Employee</button>
        </div>
        </form>
  )
}
export default DeleteEmployeeForm;