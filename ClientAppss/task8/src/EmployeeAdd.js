import React, { useState } from 'react'

export default function EmployeeAddForm(props) {

    const initialFormData = Object.freeze({
        employeeName: "",
        employeeAge: "",
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

    const handleSubmit = (e) => {
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

        props.onEmployeeAdded(employeeToAdd);
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
                    <input value={formData.employeeAge} name="employeeAge" min={18} max={99} step={10} type="number" className='form-control' onChange={handleChange} />
                </div>
                <div className='mt-5'>
                    <label className='h3 form-label'>Choise Car</label>
                    <div className="col-md-4">
                        <select value={formData.car} type="number" name="car" className='form-control' onChange={handleChange} >
                            <option value='1'>Bmw</option>
                            <option value='2'>Skoda</option>
                            <option value='3'>Toyota</option>
                            <option value='4'>Mazda</option>
                            <option value='5'>Volkswagen</option>
                        </select>
                    </div>
                </div>
                <button onClick={handleSubmit} className='btn btn-dark btn-lg w-100 mt-5'>Submit</button>
                <button onClick={() => props.OnEmployeeAdded(null)} className='btn btn-secondary btn-lg w-100 mt-3'>Cancel</button>
            </form>
        </div>
    )
}
