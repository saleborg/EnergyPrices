import React, { useEffect, useState, useCallback } from 'react'
import 'bootstrap/dist/css/bootstrap.css';

import { Table } from 'react-bootstrap';



function EnergyPriceList() {




    const [data, setData] = useState([]);

    const fetchData = useCallback(() => {
        fetch('http://localhost:5000/api/EnergyPrices/')
            .then(response => {
                if (response.ok) {
                    console.log(response);
                    return response.json()
                }
                throw response;
            }).then(d => {
                setData(d)
                console.log(d);
            });
    }, []);

    useEffect(() => {
        fetchData();
    }, [fetchData]);


    function renderTableHeader() {
        if (data.length === 0) {
            return <div className="col-lg-13" align="center">
                <p>Something went wrong when fecthing the data</p>
                <p>Someone is working on the problem so please try again in a few minutes</p>
            </div>
        }
        return (
            <tr className="thead-dark">
                <th scope="col" className="th-sm">Date</th>
                <th scope="col" className="th-sm">Bid Area</th>
                <th scope="col" className="th-sm">Contract</th>
                <th scope="col" className="th-sm">Supplier</th>
                <th scope="col" className="th-sm">Price per Öre in Kwh</th>
                <th scope="col" className="th-sm">Contract Name</th>
            </tr>
        )

    }

    function renderTableData() {
        return data.map((data, index) => {
            const { date, bidArea, contract, supplier, priceOrePerKwh, contractName } = data //destructuring
            return (

                <tr className="table-primary" key={index}>
                    <td>{date}</td>
                    <td>{bidArea}</td>
                    <td>{contract}</td>
                    <td>{supplier}</td>
                    <td>{priceOrePerKwh}</td>
                    <td>{contractName}</td>
                </tr>
            )
        })
    }


    return (
        <div className="col-lg-13" align="center">
            <Table id='sortTable' className="table table-hover table-striped table-bordered table-md" width="70%">
                <thead>
                    {renderTableHeader()}
                </thead>
                <tbody>
                    {renderTableData()}
                </tbody>

            </Table>
        </div>




    )



}
export default EnergyPriceList