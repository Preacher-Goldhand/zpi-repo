import React from "react";
import { Counter } from "./components/Counter";
import { Home } from "./components/Home";
import { MuiTest } from "./components/MuiTest";
import { CarGrid } from "./components/car/CarGrid";
import { CarAdd } from "./components/car/CarAdd";
import { CarEdit } from "./components/car/CarEdit";
import { CarDelete } from "./components/car/CarDelete";
import { CarProvider } from "./contexts/CarContext";

const AppRoutes = [
  {
    index: true,
    element: <CarGrid />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/mui-test',
    element: <MuiTest />
  },
  {
    path: '/car',
    element: <CarGrid />
  },
  {
    path: '/car/add',
    element: <CarAdd/>
  },
  {
    path: '/car/edit/:id',
    element: <CarEdit/>
  },
  {
    path: '/car/delete/:id',
    element: <CarDelete/>
  },
];

export default AppRoutes;
