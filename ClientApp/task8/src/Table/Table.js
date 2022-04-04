import React from 'react';

// eslint-disable-next-line import/no-anonymous-default-export
export default props => (
    <table className="table">
        <thead>
            <tr>
                <th onClick={props.onSort.bind(null, 'employeeid')} >
                    Id 
                {props.sortField === 'employeeId' ? <small>{props.sort}</small> : null}
                </th>
                <th onClick={props.onSort.bind(null, 'employeeName')}>EmployeeName
                {props.sortField === 'employeeName' ? <small>{props.sort}</small> : null}
                </th>
                <th onClick={props.onSort.bind(null, 'employeeAge')}>EmployeeAge
                {props.sortField === 'employeeAge' ? <small>{props.sort}</small> : null}</th>
                <th onClick={props.onSort.bind(null, 'car')}>Car
                {props.sortField === 'car' ? <small>{props.sort}</small> : null}</th>
                <th onClick={props.onSort.bind(null, 'recordId')}>RecordId
                {props.sortField === 'recordId' ? <small>{props.sort}</small> : null}</th>
            </tr>
        </thead>
        <tbody>
            {props.data.map(item => (
                <tr key={item.employeeId}>
                    <th >{item.employeeId}</th>
                    <td>{item.employeeName}</td>
                    <td>{item.employeeAge}</td>
                    <td>{item.car}</td>
                    <td>{item.recordId}</td>
                </tr>
            ))}
        </tbody>
    </table>
)