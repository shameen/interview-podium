import React from "react";
import { render } from "@testing-library/react";
import App from "./App";

test("renders form submit button", () => {
    const { getByText } = render(<App />);
    const submitElement = getByText(/Continue/i);
    expect(submitElement).toBeInTheDocument();
});