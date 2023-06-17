import { axios } from "../lib/axios"
import { timeToIsoDate } from "../utils"

export const signupRestaurant = async ({restaurantName, ownerName, openTime, closeTime, address, password}) => {
    return axios.post("/Resturant/resturant-register", {
        "restaurantID": (Math.random() + 1).toString(36).substring(7),
        "name": restaurantName,
        "password": password,
        "manager": ownerName,
        "openTime": timeToIsoDate(openTime),
        "closeTime": timeToIsoDate(closeTime),
        "address": address,
        "balance": 1000000
    }).then(res => localStorage.setItem("user", JSON.stringify(res.data)))
}