import { useState } from "react";

export const useForm = (callback, initialValues = {}) => {
    const [formData, setFormData] = useState(initialValues);

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData((prevData) => ({ ...prevData, [name]: value }));
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        callback();
    };

    return {
        formData,
        handleChange,
        handleSubmit,
        setFormData
    };
};
