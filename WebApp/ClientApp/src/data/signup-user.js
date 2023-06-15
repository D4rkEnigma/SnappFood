import { axios } from "../lib/axios"

export const signupUser = async ({firstName, lastName, nationalCode, address, password}) => {
    return axios.post("/User/registeruser", {
        "userID": (Math.random() + 1).toString(36).substring(7),
        "nationalCode": nationalCode,
        "password": password,
        "name": firstName + " " + lastName,
        "balance": 9999999999999,
        "address": address
    }).then(res => localStorage.setItem("user", JSON.stringify(res.data)))
}