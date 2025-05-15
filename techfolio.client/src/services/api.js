const BASE_URL = "";

export async function registerFromInvitation(data, token) {
    const res = await fetch(`${BASE_URL}/auth/register/invite`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${token}`
        },
        body: JSON.stringify(data)
    });

    if (!res.ok) {
        throw new Error("?????? ??? ?????????????.");
    }

    return await res.json();
}

export async function submitStudentProfile(data, token) {
    const res = await fetch(`${BASE_URL}/student/profile`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${token}`
        },
        body: JSON.stringify(data)
    });

    if (!res.ok) {
        throw new Error("?????? ??? ????????? ?? ???????.");
    }

    return await res.json();
}

