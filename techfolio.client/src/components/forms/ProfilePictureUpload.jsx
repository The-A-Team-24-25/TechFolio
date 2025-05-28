import React, { useState, useRef } from 'react';

const ProfilePictureUpload = ({ studentId }) => {
    const [previewUrl, setPreviewUrl] = useState(null);
    const [error, setError] = useState('');
    const fileInputRef = useRef();

    const handleFileSelect = () => {
        fileInputRef.current.click();
    };

    const handleFileChange = async (e) => {
        const file = e.target.files[0];
        if (!file) return;

        const validTypes = ['image/jpeg', 'image/png', 'image/gif'];
        if (!validTypes.includes(file.type)) {
            setError('Позволени формати: JPG, PNG, GIF');
            return;
        }

        if (file.size > 2 * 1024 * 1024) {
            setError('Файлът трябва да е под 2MB');
            return;
        }

        setError('');
        const formData = new FormData();
        formData.append('profilePicture', file);

        try {
            await fetch(`/students/${studentId}/profile-picture`, {
                method: 'POST',
                body: formData,
            });

            const imageUrl = URL.createObjectURL(file);
            setPreviewUrl(imageUrl);
        } catch {
            setError('Грешка при качване на файла');
        }
    };

    return (
        <form onSubmit={(e) => e.preventDefault()}>
            <label htmlFor="fileUpload">Качи снимка:</label><br />
            <button type="button" onClick={handleFileSelect}>Избери файл</button>
            <input
                type="file"
                id="fileUpload"
                accept="image/*"
                onChange={handleFileChange}
                ref={fileInputRef}
                style={{ display: 'none' }}
            />
            {error && <p style={{ color: 'red' }}>{error}</p>}
            {previewUrl && (
                <div>
                    <p>Преглед:</p>
                    <img src={previewUrl} alt="Профилна снимка" width={150} />
                </div>
            )}
        </form>
    );
};

export default ProfilePictureUpload;