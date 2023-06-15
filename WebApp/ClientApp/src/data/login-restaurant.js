import { axios } from "../lib/axios"

export const loginRestaurant = async ({restaurantName, password}) => {
    return axios.post("/Resturant/login", {
        "userName": restaurantName,
        "password": password
    }).then(res => localStorage.setItem("user", JSON.stringify(res.data)))
}