import * as React from "react";
export const CommandCell = (props) => {
  const { dataItem } = props;
  return (
    <td className="k-command-cell">
      <button
        className="k-button k-button-md k-rounded-md k-button-solid k-button-solid-primary k-grid-remove-command"
        onClick={() =>
          props.showDialog(dataItem)
        }
      >
        Remove
      </button>
    </td>
  );
};