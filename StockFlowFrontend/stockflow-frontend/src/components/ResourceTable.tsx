import type { ResourceDto } from "../api/resources";

interface Props {
  resources: ResourceDto[];
  onDelete: (id: string) => void;
}

export function ResourceTable({ resources, onDelete }: Props) {
  return (
    <table style={{ width: "100%", borderCollapse: "collapse" }}>
      <thead>
        <tr>
          <th>ID</th>
          <th>Название</th>
          <th></th>
        </tr>
      </thead>
      <tbody>
        {resources.map((r) => (
          <tr key={r.id}>
            <td>{r.id}</td>
            <td>{r.name}</td>
            <td>
              <button onClick={() => onDelete(r.id)}>❌</button>
            </td>
          </tr>
        ))}
      </tbody>
    </table>
  );
}
