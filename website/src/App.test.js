import React from 'react';
import { render } from '@testing-library/react';
import App from './App';

test('renders SA Interiew logo suffix', () => {
    const { getByText } = render(<App />);
    const linkElement = getByText(/SA Case Study/i);
    expect(linkElement).toBeInTheDocument();
});
