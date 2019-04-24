from bottle import route, run
import sqlite3
import json

db_file = 'Database/tool_coord_param.db'


@route('/api/gettools', method=['GET', 'POST'])
def gettools():

    db_conn = sqlite3.connect(db_file)
    db_cursor = db_conn.cursor()
    db_cursor.execute(
        "SELECT tool_name, end_pos_x, end_pos_y, end_pos_z, end_ori_rx, end_ori_ry, end_ori_rz FROM tool_param_view")
    records = db_cursor.fetchall()
    db_cursor.close()

    if not records:
        return {}
    else:
        data = []
        for record in records:
            tmp = []
            # tool name
            tmp.append({"tool_name": record[0],
                        # pos
                        "x": record[1],
                        "y": record[2],
                        "z": record[3],
                        # ori
                        "rx": record[4],
                        "ry": record[5],
                        "rz": record[6]
                        })
            data.append(tmp)

        return json.dumps(data)
        # return json.dumps(data, default=lambda obj: obj.__dict__, sort_keys=True)


@route('/api/getcoords', method=['GET', 'POST'])
def getcoords():

    db_conn = sqlite3.connect(db_file)
    db_cursor = db_conn.cursor()
    db_cursor.execute("SELECT * FROM coord_param_View")
    records = db_cursor.fetchall()
    db_cursor.close()

    if not records:
        return {}
    else:
        data = []
        for record in records:
            tmp = []
            # coord name
            tmp.append({"coord_name": record[0],
                        # method
                        "method": record[1],
                        # 3 waypoints
                        "point1": record[2],
                        "point2": record[3],
                        "point3": record[4],
                        # tool name
                        "tool_name": record[5],
                        # pos
                        "x": record[6],
                        "y": record[7],
                        "z": record[8],
                        # ori
                        "rx": record[9],
                        "ry": record[10],
                        "rz": record[11]
                        })
            # add record
            data.append(tmp)

        return json.dumps(data)


if __name__ == "__main__":
    run(host='0.0.0.0', port=8080, reloader=True)
