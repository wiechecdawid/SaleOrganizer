export const resetToken = () => {
    window.localStorage.removeItem('jwt')
}

export const saveToken = (token: string) => {
    window.localStorage.setItem('jwt', token)
}

export const getToken = () => window.localStorage.getItem('jwt')