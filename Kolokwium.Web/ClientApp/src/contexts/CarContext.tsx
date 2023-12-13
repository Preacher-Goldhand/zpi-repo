import React, { useState } from "react";
import { ICar } from "../models/ICar";
import axios from 'axios';



const CarContext = React.createContext({});

type IProps = { children: React.ReactNode};
type IState = { cars: ICar[]};

export const CarProvider = (props: IProps) => {
    const [state, setState] = useState<IState>({cars: []});

    const getCars = async () => {
        const response = await axios.get<ICar[]>("/api/Car");
        setState({ cars: response.data});
    }

    return (
        <CarContext.Provider value={{
            state,
            getCars
        }}>
            {props.children}
        </CarContext.Provider>
    );
}
export default CarContext;