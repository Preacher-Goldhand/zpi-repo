import { ICar } from "../../models/ICar";
import { DataGrid, GridColDef, GridRenderCellParams } from '@mui/x-data-grid';
import { Link } from 'react-router-dom';
import CarContext from "../../contexts/CarContext";
import { useContext, useEffect } from "react";
import React from "react";

type IState = {
    cars: ICar[];
}

export const CarGrid = () => {

    const columns: GridColDef[] = [
        {field: 'id', headerName: 'id', width: 20},
        {field: 'name', headerName: 'name', width: 20},
        {field: 'brand', headerName: 'brand', width: 20},
        {field: 'yearOfProduction', headerName: 'yearOfProduction', width: 20},
        {
            field: "edit",
            headerName: "Edit",
            sortable: false,
            renderCell: (params: GridRenderCellParams) => {
                const car: ICar = params.row;
                return <Link to={`/car/edit/${car.id}`} className="btn btn-primary"> Edit </Link>
            }
        },
        {
            field: "delete",
            headerName: "Delete",
            sortable: false,
            renderCell: (params: GridRenderCellParams) => {
                const car: ICar = params.row;
                return <Link to={`/car/delete/${car.id}`} className="btn btn-primary"> Delete </Link>
            }
        }
    ]

    const {getCars, state}: any = useContext(CarContext);
    
    useEffect(() => {
        getCars()
    }, []);

    return (
        <div>
            <Link to={`/car/add`} className="btn btn-primary">Add</Link>
            <div className="car-grid">
                <div>
                    <DataGrid
                        rows={state.cars}
                        columns={columns}
                        checkboxSelection
                    />
                </div>
            </div>
        </div>
    )
}