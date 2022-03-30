import React, { useState } from 'react'

export default function EmployeeAddForm(props) {
    const initialFormData = Object.freeze({
        employeeName: "Eugene",
        employeeAge: 20,
        car: 3,
        recordId: ""
    });

    const [formData, setFormData] = useState(initialFormData);



    const handleChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value,
        });
    };

    const handleSubmit = (e) => {
        e.preventDefault();

        const employeeToAdd = {
            employeeId: 0,
            employeeName: formData.employeeName,
            employeeAge: formData.employeeAge,
            car: formData.car,
            recordId: formData.recordId
        };


        const url = 'https://localhost:44310/api/employees';

        fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(employeeToAdd)
        })
            .then(response => response.json())
            .then(responseFromServer => {
                console.log(responseFromServer);
            })
            .catch((error) => {
                console.log(error);
                alert(error);
            });

        props.OnEmployeeAdded(employeeToAdd);
    };

    return (
        <div>
            <form className='w-100 px-5'>
                <h1 className='mt-5'>Add new Employee</h1>

                <div className='mt-5'>
                    <label className='h3 form-label'>Input Name</label>
                    <input value={formData.employeeName} name="employeeName" type="text" className='form-control' onChange={handleChange} />
                </div>
                <div className='mt-4'>
                    <label className='h3 form-label'>Input Age</label>
                    <input value={formData.employeeAge} name="employeeAge" type="number" className='form-control' onChange={handleChange} />
                </div>
                <div className='mt-5'>
                    <label className='h3 form-label'>Choise Car</label>
                    <input value={formData.car} name="car" type="number" className='form-control' onChange={handleChange} />
                </div>
                <div className='mt-5'>
                    <label className='h3 form-label'>uu</label>
                    <input value={formData.recordId} name="recordId" type="text" className='form-control' onChange={handleChange} />
                </div>
                <button onClick={handleSubmit} className='btn btn-dark btn-lg w-100 mt-5'>Submit</button>
                <button onClick={() => props.OnEmployeeAdded(null)} className='btn btn-secondary btn-lg w-100 mt-3'>Cancel</button>
            </form>
        </div>
    )
}
