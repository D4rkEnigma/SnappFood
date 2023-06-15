import { axios } from "../lib/axios"

export const loginUser = async ({nationalCode, password}) => {
    return axios.post("/User/loginuser", {
        "userName": nationalCode,
        "password": password
    }).then(res => localStorage.setItem("user", JSON.stringify(res.data)))
}