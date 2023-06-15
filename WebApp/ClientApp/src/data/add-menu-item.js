import { DateTime } from "luxon";
import { axios } from "../lib/axios"

export const addMenuItem = async ({foodName, price, cookingTime, restaurantName}) => {
    return axios.post("/Resturant/add-menuitem", {
        "foodName": foodName,
        "price": Number(price),
        "cooockingTime": DateTime.fromISO(cookingTime).toISO(),
        "resturantID": restaurantName,
    });
}