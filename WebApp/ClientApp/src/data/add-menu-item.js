import { axios } from "../lib/axios"
import { timeToIsoDate } from "../utils";

export const addMenuItem = async ({foodName, price, cookingTime, restaurantName}) => {
    return axios.post("/Resturant/add-menuitem", {
        "foodName": foodName,
        "price": Number(price),
        "cooockingTime": timeToIsoDate(cookingTime),
        "resturantID": restaurantName,
    });
}