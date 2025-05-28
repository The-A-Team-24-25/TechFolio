fimport React, { useState, useEffect } from 'react';
import axios from 'axios';

function FormAddInterest() {
    const [interests, setInterests] = useState([]);
    const [selected, setSelected] = useState('');
    const [custom, setCustom] = useState('');

    useEffect(() => {
        axios.get('https://localhost:5001/api/interests')
            .then(res => setInterests(res.data))
            .catch(err => console.error(err));
    }, []);

    const handleSubmit = async (e) => {
        e.preventDefault();
        const name = selected === 'custom' ? custom : selected;
        if (!name) return;
        await axios.post('https://localhost:5001/api/interests', { name });
        alert('Interest saved!');
        setSelected('');
        setCustom('');
    };

    return (
        <form onSubmit={handleSubmit}>
            <label>Select Interest:</label>
            <select value={selected} onChange={e => setSelected(e.target.value)}>
                <option value="">-- Choose --</option>
                {interests.map(interest => (
                    <option key={interest.id} value={interest.name}>
                        {interest.name}
                    </option>
                ))}
                <option value="custom">Other</option>
            </select>

            {selected === 'custom' && (
                <>
                    <label>Custom Interest:</label>
                    <input
                        type="text"
                        value={custom}
                        onChange={e => setCustom(e.target.value)}
                    />
                </>
            )}

            <button type="submit">Save</button>
        </form>
    );
}

export default FormAddInterest;