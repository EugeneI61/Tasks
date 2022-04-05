import React, { useState } from 'react'

const EmployeeAddForm = props => {

    const initialFormData = Object.freeze({
        employeeAge: '',
        employeeName: '',
        car: 3,
    });
    const [formData, setFormData] = useState(initialFormData);


    const handleChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value,
        });
    };

    // eslint-disable-next-line no-extend-native
    String.prototype.hashCode = function () {
        var hash = 0;
        for (var i = 0; i < this.length; i++) {
            var char = this.charCodeAt(i);
            hash = ((hash << 5) - hash) + char;
            hash = hash & hash;
        }
        return hash;
    }

    function addEmployee(e) {

        e.preventDefault();

        const employeeToAdd = {
            employeeId: 0,
            employeeName: formData.employeeName,
            employeeAge: formData.employeeAge,
            car: Number.parseInt(formData.car),
            recordId: (formData.employeeName + formData.employeeAge + Number.parseInt(formData.car)).hashCode().toString()
        };

        const url = "https://localhost:44310/api/employees";

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
                console.log(employeeToAdd)
            })
            .catch((error) => {
                console.log(error);
                alert(error);
            });
    }

    const handleSubmit = (e) => {
        if (formData.employeeName !== "") {
            if (formData.employeeAge < 18 || formData.employeeAge > 99) {
                alert('Age must be in range 18 - 99')
            } else {
                alert("Employee was Add!");
                addEmployee(e);
            }
        } else {
            alert("Input Name!")
        }
    };

    return (
        <form className='w-50 px-5'>
            <h1 className='mt-5'>Add new Employee</h1>
            <div className='mt-5'>

                <label className='h3 form-label'>Input Name</label>
                <input value={formData.employeeName} name="employeeName" type="text" className='form-control' onChange={handleChange} />
            </div>
            <div className='mt-4'>

                <label className='h3 form-label'>Input Age</label>
                <input value={formData.employeeAge} name="employeeAge" type="number" className='form-control' onChange={handleChange} />
            </div>
            <div className='mt-4'>
                <label className='h3 form-label'>Choise Car</label>
                <select value={formData.car} type="number" name="car" className='form-control' onChange={handleChange}>
                    <option value='1'>Bmw</option>
                    <option value='2'>Skoda</option>
                    <option value='3'>Toyota</option>
                    <option value='4'>Mazda</option>
                    <option value='5'>Volkswagen</option>
                </select>
            </div>
            <button onClick={handleSubmit} className='btn btn-dark btn-lg w-25 mt-5'>Submit</button>
        </form>
    )
}

export default EmployeeAddForm;